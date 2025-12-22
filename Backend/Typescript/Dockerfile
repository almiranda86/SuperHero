# ==========================================
# Multi-Stage Dockerfile for Node.js TypeScript App
# Optimized for production with minimal image size
# ==========================================

# ==========================================
# Stage 1: Dependencies
# ==========================================
FROM node:20-alpine AS dependencies

WORKDIR /app

# Copy package files
COPY package*.json ./

# Install ALL dependencies (including devDependencies for build)
RUN npm install --silent

# ==========================================
# Stage 2: Build
# ==========================================
FROM node:20-alpine AS builder

WORKDIR /app

# Copy dependencies from previous stage
COPY --from=dependencies /app/node_modules ./node_modules

# Copy source code
COPY . .

# Generate Prisma Client
RUN npx prisma generate

# TypeScript is already compiled on-the-fly by tsx
# No build step needed for tsx projects

# ==========================================
# Stage 3: Production Dependencies
# ==========================================
FROM node:20-alpine AS production-deps

WORKDIR /app

# Copy package files
COPY package*.json ./

# Install only production dependencies + tsx for runtime
RUN npm install --omit=dev --silent && \
    npm install tsx --silent && \
    npm cache clean --force

# ==========================================
# Stage 4: Production Runtime
# ==========================================
FROM node:20-alpine AS production

# Install dumb-init and OpenSSL for Prisma
RUN apk add --no-cache dumb-init openssl

# Create non-root user
RUN addgroup -g 1001 -S nodejs && \
    adduser -S nodejs -u 1001

WORKDIR /app

# Copy production dependencies
COPY --from=production-deps --chown=nodejs:nodejs /app/node_modules ./node_modules

# Copy application source
COPY --chown=nodejs:nodejs . .

# Copy Prisma generated client from builder
COPY --from=builder --chown=nodejs:nodejs /app/node_modules/.prisma ./node_modules/.prisma
COPY --from=builder --chown=nodejs:nodejs /app/node_modules/@prisma ./node_modules/@prisma

# Ensure prisma directory exists
RUN mkdir -p /app/prisma && \
    mkdir -p /app/data && \
    chown -R nodejs:nodejs /app/prisma /app/data

# Switch to non-root user
USER nodejs

# Expose application port
EXPOSE 3000

# Environment variables
ENV NODE_ENV=production \
    PORT=3000

# Health check
HEALTHCHECK --interval=30s --timeout=10s --start-period=40s --retries=3 \
    CMD node -e "require('http').get('http://localhost:3000', (r) => {process.exit(r.statusCode === 200 ? 0 : 1)})"

# Use dumb-init to handle signals properly
ENTRYPOINT ["dumb-init", "--"]

# Run Prisma migrations and start app
# Note: tsx needs to be in production deps or use node with ts-node
CMD ["sh", "-c", "npx prisma db push --accept-data-loss && npx tsx src/index.ts"]

# ==========================================
# Stage 5: Development (Optional)
# ==========================================
FROM node:20-alpine AS development

WORKDIR /app

# Copy package files
COPY package*.json ./

# Install all dependencies including dev
RUN npm install --silent

# Copy source
COPY . .

# Generate Prisma Client
RUN npx prisma generate

# Expose port
EXPOSE 3000

# Development command with hot-reload
CMD ["npm", "run", "dev"]

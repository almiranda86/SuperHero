// MongoDB initialization script
// This script runs when the container is first created

// Switch to HeroesDB database
db = db.getSiblingDB('HeroesDB');

// Create collections
db.createCollection('Heroes');
db.createCollection('BaseHeroes');

// Create indexes for better performance
db.Heroes.createIndex({ "publicId": 1 }, { unique: true });
db.Heroes.createIndex({ "name": 1 });
db.Heroes.createIndex({ "biography.fullName": 1 });

db.BaseHeroes.createIndex({ "privateId": 1 }, { unique: true });
db.BaseHeroes.createIndex({ "publicId": 1 }, { unique: true });

// Create a user for the application (optional, but recommended)
db.createUser({
  user: process.env.MONGO_APP_USER || 'superhero_app',
  pwd: process.env.MONGO_APP_PASSWORD || 'changeme',
  roles: [
    {
      role: 'readWrite',
      db: 'HeroesDB'
    }
  ]
});

// Log success
print('MongoDB initialized successfully for SuperHero TypeScript API');
print('Database: HeroesDB');
print('Collections: Heroes, BaseHeroes');
print('Indexes created successfully');

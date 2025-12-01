import { startServer } from './server.js';
import doEnvironmentSetup from './services/configuration/setup-environment.js';

async function start() {
  // Runs setup environment configurations before starting the server
  await doEnvironmentSetup();
  await startServer();
}

start();
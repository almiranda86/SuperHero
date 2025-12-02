import { addRepository, addServices } from './ioc/container-config.js';
import { startServer } from './server.js';
import doEnvironmentSetup from './services/configuration/setup-environment.js';

async function start() {
  //Runs DI container configuration
  addServices();
  addRepository();

  // Runs setup environment configurations before starting the server
  await doEnvironmentSetup();
  await startServer();
}

start();
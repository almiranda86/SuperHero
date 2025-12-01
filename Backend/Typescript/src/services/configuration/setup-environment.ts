import initializeDb from "./setup-database.js";

export default async function doEnvironmentSetup() {
    await initializeDb();
}
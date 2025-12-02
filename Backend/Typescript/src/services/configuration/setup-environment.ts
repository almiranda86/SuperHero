import { container } from "tsyringe";
import SetupDBService from "./setup-database.js";

export default async function doEnvironmentSetup() {
    const setupService = container.resolve(SetupDBService);
    await setupService.InitializeDb();
}
import { Expose } from "class-transformer";
import type { GuidId } from "./guid-id.js";
import { v4 as uuidv4, validate, version } from 'uuid';

export class BaseHero implements GuidId {
        publicId: string | undefined;
        PrivateId: number | undefined;
        @Expose({ name: "name" })
        Name:  string | undefined;

        constructor(privateId: number, name: string) { 
            this.publicId = uuidv4();
            this.PrivateId = privateId;
            this.Name = name;
        }
}
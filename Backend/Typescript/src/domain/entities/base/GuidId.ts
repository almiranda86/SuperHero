import { Expose } from "class-transformer";

export class GuidId {
    @Expose({ name: "public_id" })
    publicId: string | undefined;
}
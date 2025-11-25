import { Expose } from "class-transformer";

export class Image {
    @Expose({ name: "url" })
    public URL: string | undefined;
}
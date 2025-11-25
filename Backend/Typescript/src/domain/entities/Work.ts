import { Expose } from "class-transformer";

export class Work {
    @Expose({ name: "occupation" })
     occupation: string | undefined;

    @Expose({ name: "base" })
     baseOfOperation: string | undefined;
}
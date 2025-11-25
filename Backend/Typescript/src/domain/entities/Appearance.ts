import { Expose } from "class-transformer";

export class Appearance {
    @Expose({ name: "gender" })
    public Gender: string | undefined;

    @Expose({ name: "race" })
    public Race: string | undefined;

    @Expose({ name: "height" })
    public Height: string[] | undefined;

    @Expose({ name: "weight" })
    public Weight: string[] | undefined;

    @Expose({ name: "eye-color" })
    public EyeColor: string | undefined;

    @Expose({ name: "hair-color" })
    public HairColor: string | undefined;
}

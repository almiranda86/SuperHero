import { Expose } from "class-transformer";

export class Biography {
    @Expose({ name: "full-name" })
    public FullName: string | undefined;

    @Expose({ name: "alter-egos" })
    public AlterEgos: string | undefined;

    @Expose({ name: "aliases" })
    public Aliases: string[] | undefined;

    @Expose({ name: "place-of-birth" })
    public PlaceOfBirth: string | undefined;

    @Expose({ name: "first-appearance" })
    public FirstAppearance: string | undefined;

    @Expose({ name: "publisher" })
    public Publisher: string | undefined;

    @Expose({ name: "alignment" })
    public Alignment: string | undefined;

}
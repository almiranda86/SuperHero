import { Expose } from "class-transformer";

export class Powerstats {

    @Expose({ name: "intelligence" })
    public Intelligence: string | undefined;

    @Expose({ name: "strength" })
    public Strength: string | undefined;

    @Expose({ name: "speed" })
    public Speed: string | undefined;

    @Expose({ name: "durability" })
    public Durability: string | undefined;

    @Expose({ name: "power" })
    public Power: string | undefined;

    @Expose({ name: "combat" })
    public Combat: string | undefined;
}
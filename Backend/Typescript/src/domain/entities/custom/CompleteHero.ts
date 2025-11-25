import { Expose } from "class-transformer";
import { GuidId } from "../base/guidId.js";
import { Powerstats } from "../Powerstats.js";
import { Biography } from "../Biography.js";
import { Appearance } from "../Appearance.js";
import { Work } from "../Work.js";
import { Connections } from "../Connections.js";
import { Image } from "../Image.js";

export class CompleteHero extends GuidId {
    @Expose({ name: "powerstats" })
    powerstats: Powerstats = new Powerstats();

    @Expose({ name: "biography" })
    biography: Biography = new Biography();

    @Expose({ name: "appearance" })
    appearance: Appearance = new Appearance();

    @Expose({ name: "work" })
    work: Work = new Work();

    @Expose({ name: "connections" })
    connections: Connections = new Connections();

    @Expose({ name: "image" })
    image: Image = new Image();

    @Expose({ name: "name" })
    name: string | undefined;

    @Expose({ name: "public_id" })
    PublicId: string | undefined;
}
import { Expose } from "class-transformer";

export class Connections {

    @Expose({ name: "group-affiliation" })
    public GroupAffiliation: string | undefined;

    @Expose({ name: "relatives" })
    public Relatives: string | undefined;
}
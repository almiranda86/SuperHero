package com.superhero.domain.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonProperty;

public final class Connections implements Serializable {

    @JsonProperty("group-affiliation")
    public String groupAffiliation;

    @JsonProperty("relatives")
    public String relatives;
    
    public Connections() {
    }

    public String getGroupAffiliation() {
        return groupAffiliation;
    }

    public void setGroupAffiliation(String groupAffiliation) {
        this.groupAffiliation = groupAffiliation;
    }

    public String getRelatives() {
        return relatives;
    }

    public void setRelatives(String relatives) {
        this.relatives = relatives;
    }
}

package com.superhero.domain.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonProperty;

public final class Powerstats implements Serializable{

    @JsonProperty("intelligence")
    public String intelligence;

    @JsonProperty("strength")
    public String strength;

    @JsonProperty("speed")
    public String speed;

    @JsonProperty("durability")
    public String durability;

    @JsonProperty("power")
    public String power;

    @JsonProperty("combat")
    public String combat;
    

    public Powerstats() {
    }

    public String getIntelligence() {
        return intelligence;
    }

    public void setIntelligence(String intelligence) {
        this.intelligence = intelligence;
    }

    public String getStrength() {
        return strength;
    }

    public void setStrength(String strength) {
        this.strength = strength;
    }

    public String getSpeed() {
        return speed;
    }

    public void setSpeed(String speed) {
        this.speed = speed;
    }

    public String getDurability() {
        return durability;
    }

    public void setDurability(String durability) {
        this.durability = durability;
    }

    public String getPower() {
        return power;
    }

    public void setPower(String power) {
        this.power = power;
    }

    public String getCombat() {
        return combat;
    }

    public void setCombat(String combat) {
        this.combat = combat;
    }

}

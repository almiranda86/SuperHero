package com.superhero.domain.model;

import java.io.Serializable;
import java.util.List;

import com.fasterxml.jackson.annotation.JsonProperty;

public final class Appearance implements Serializable {
    
    @JsonProperty("gender")
    public String gender;
    
    @JsonProperty("race")
    public String race;
    
    @JsonProperty("height")
    public List<String> height;
    
    @JsonProperty("weight")
    public List<String> weight;
    
    @JsonProperty("eye-color")
    public String eyeColor;
    
    @JsonProperty("hair-color")
    public String hairColor;

    public Appearance() {
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }
    
    public String getRace() {
        return race;
    }

    public void setRace(String race) {
        this.race = race;
    }
    
    public List<String> getHeight() {
        return height;
    }

    public void setHeight(List<String> height) {
        this.height = height;
    }
    
    public List<String> getWeight() {
        return weight;
    }

    public void setWeight(List<String> weight) {
        this.weight = weight;
    }
    
    public String getEyeColor() {
        return eyeColor;
    }

    public void setEyeColor(String eyeColor) {
        this.eyeColor = eyeColor;
    }
    
    public String getHairColor() {
        return hairColor;
    }

    public void setHairColor(String hairColor) {
        this.hairColor = hairColor;
    }
}

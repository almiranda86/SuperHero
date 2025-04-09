package com.superhero.domain.model.custom_model;

import com.fasterxml.jackson.annotation.JsonGetter;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonSetter;
import com.superhero.domain.model.Appearance;
import com.superhero.domain.model.Biography;
import com.superhero.domain.model.Connections;
import com.superhero.domain.model.Image;
import com.superhero.domain.model.Powerstats;
import com.superhero.domain.model.Work;

public class CompleteHero {
    
    @JsonProperty("response")
    public String Response;

    @JsonProperty("powerstats")
    public Powerstats Powerstats;
    
    @JsonProperty("biography")
    public Biography Biography;

    @JsonProperty("appearance")
    public Appearance Appearance;
    
    @JsonProperty("work")
    public Work Work;
    
    @JsonProperty("connections")
    public Connections Connections;
    
    @JsonProperty("image")
    public Image Image;

    @JsonProperty("name")
    public String Name;

    @JsonProperty("id")
    public String PublicId;

    public CompleteHero() {
    }

    public String getResponse() {
        return Response;
    }

    public void setResponse(String response) {
        Response = response;
    }

    public Powerstats getPowerstats() {
        return Powerstats;
    }

    public void setPowerstats(Powerstats powerstats) {
        Powerstats = powerstats;
    }
    
    public Biography getBiography() {
        return Biography;
    }

    public void setBiography(Biography biography) {
        Biography = biography;
    }
    
    public Appearance getAppearance() {
        return Appearance;
    }

    public void setAppearance(Appearance appearance) {
        Appearance = appearance;
    }
    
    public Work getWork() {
        return Work;
    }

    public void setWork(Work work) {
        Work = work;
    }
    
    public Connections getConnections() {
        return Connections;
    }

    public void setConnections(Connections connections) {
        Connections = connections;
    }
    
    public Image getImage() {
        return Image;
    }

    public void setImage(Image image) {
        Image = image;
    }
    
    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }
    
    public String getPublicId() {
        return PublicId;
    }

    public void setPublicId(String publicId) {
        PublicId = publicId;
    }
}

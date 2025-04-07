package com.superhero.domain.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonProperty;

public final class Image implements Serializable {

    @JsonProperty("url")
    public String URL;

    public Image() {
    }

    public String getURL() {
        return URL;
    }

    public void setURL(String uRL) {
        URL = uRL;
    }
}

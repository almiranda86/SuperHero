package com.superhero.domain.model;

import java.io.Serializable;

import com.fasterxml.jackson.annotation.JsonProperty;

public final class Work implements Serializable{
    @JsonProperty("occupation")
    public String occupation;

    @JsonProperty("base")
    public String baseOfOperation;
    
    public Work() {
    }

    public String getOccupation() {
        return occupation;
    }

    public void setOccupation(String occupation) {
        this.occupation = occupation;
    }

    public String getBaseOfOperation() {
        return baseOfOperation;
    }

    public void setBaseOfOperation(String baseOfOperation) {
        this.baseOfOperation = baseOfOperation;
    }
}

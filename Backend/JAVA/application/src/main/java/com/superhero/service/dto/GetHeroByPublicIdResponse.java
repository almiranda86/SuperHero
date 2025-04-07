package com.superhero.service.dto;

import com.fasterxml.jackson.annotation.JsonProperty;
import com.superhero.domain.model.custom_model.CompleteHero;
import com.superhero.service.ServiceResponse;

public class GetHeroByPublicIdResponse extends ServiceResponse {

    @JsonProperty("hero")

    public CompleteHero Hero;

    public GetHeroByPublicIdResponse() {
        Hero = new CompleteHero();
    }

    public CompleteHero getCompleteHero() {
        return Hero;
    }

    public void SetCompleteHero(CompleteHero hero) {
        Hero = hero;
    }
}

package com.superhero.service.dto;

import com.superhero.domain.model.custom_model.CompleteHero;
import com.superhero.service.ServiceResponse;

public class GetHeroByPublicIdResponse extends ServiceResponse {
        public CompleteHero Hero;

        public CompleteHero getCompleteHero() {
            return Hero;
        }

        public GetHeroByPublicIdResponse()
        {
            Hero = new CompleteHero();
        }

        public void SetCompleteHero(CompleteHero hero)
        {
            Hero = hero;
        }

}

package com.superhero.domain.behavior.repository.lookup;

import com.superhero.domain.model.custom_model.CompleteHero;

public interface IExternalApiLookup {
    CompleteHero GetCompleteHeroById(int heroId);
}

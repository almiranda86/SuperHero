package com.superhero.repository.lookup;

import org.springframework.beans.factory.annotation.Autowired;

import com.superhero.domain.behavior.repository.lookup.IExternalApiLookup;
import com.superhero.domain.behavior.service.external_service.IRestService;
import com.superhero.domain.model.custom_model.CompleteHero;

public class ExternalApiLookup implements IExternalApiLookup {

    @Autowired
    private final IRestService restService;

    public ExternalApiLookup(IRestService restService) {
        this.restService = restService;
    }

    @Override
    public CompleteHero GetCompleteHeroById(int heroId) {
        // TODO Auto-generated method stub
        throw new UnsupportedOperationException("Unimplemented method 'GetCompleteHeroById'");
    }

}

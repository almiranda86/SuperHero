package com.superhero.handler;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.superhero.domain.behavior.handler.IGetHeroByPublicIdHandler;
import com.superhero.domain.behavior.repository.lookup.IBaseHeroLookup;
import com.superhero.domain.behavior.repository.lookup.IExternalApiLookup;
import com.superhero.domain.model.BaseHero;
import com.superhero.domain.model.custom_model.CompleteHero;
import com.superhero.service.dto.GetHeroByPublicIdResponse;

@Component
public class GetHeroByPublicIdHandler implements IGetHeroByPublicIdHandler{

    @Autowired
    private final IBaseHeroLookup baseHeroLookup;
    
    @Autowired
    private final IExternalApiLookup externalApiLookup;

    public GetHeroByPublicIdHandler(IBaseHeroLookup baseHeroLookup,
                                    IExternalApiLookup externalApiLookup) {
        this.baseHeroLookup = baseHeroLookup;
        this.externalApiLookup = externalApiLookup;
    }

    @Override
    public GetHeroByPublicIdResponse GetByPublicId(String publicId) {
        
        BaseHero baseHero = this.baseHeroLookup.getBaseHeroByPublicId(publicId);

        CompleteHero completeHero = this.externalApiLookup.GetCompleteHeroById(baseHero.getPrivateId());

        GetHeroByPublicIdResponse response = new GetHeroByPublicIdResponse();
        response.SetCompleteHero(completeHero);
        
        return response;
        
    }

}

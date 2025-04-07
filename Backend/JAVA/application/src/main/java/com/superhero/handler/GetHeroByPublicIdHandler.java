package com.superhero.handler;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.superhero.domain.behavior.handler.IGetHeroByPublicIdHandler;
import com.superhero.domain.behavior.repository.lookup.IBaseHeroLookup;
import com.superhero.domain.model.BaseHero;

@Component
public class GetHeroByPublicIdHandler implements IGetHeroByPublicIdHandler{

    @Autowired
    private final IBaseHeroLookup baseHeroLookup;

    public GetHeroByPublicIdHandler(IBaseHeroLookup baseHeroLookup) {
        this.baseHeroLookup = baseHeroLookup;
    }

    @Override
    public BaseHero GetByPublicId(String publicId) {
        return this.baseHeroLookup.getBaseHeroByPublicId(publicId);
    }

}

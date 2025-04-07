package com.superhero.domain.behavior.handler;

import org.springframework.stereotype.Component;

import com.superhero.domain.model.BaseHero;

@Component
public interface IGetHeroByPublicIdHandler {
    BaseHero GetByPublicId(String publicId);
}

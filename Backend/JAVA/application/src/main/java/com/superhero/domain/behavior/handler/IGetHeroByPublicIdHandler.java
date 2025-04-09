package com.superhero.domain.behavior.handler;

import org.springframework.stereotype.Component;

import com.superhero.service.dto.GetHeroByPublicIdResponse;

@Component
public interface IGetHeroByPublicIdHandler {
    GetHeroByPublicIdResponse GetByPublicId(String publicId);
}

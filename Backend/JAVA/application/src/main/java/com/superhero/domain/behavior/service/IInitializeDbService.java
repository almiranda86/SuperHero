package com.superhero.domain.behavior.service;

import java.util.List;

import com.superhero.domain.model.BaseHero;

public interface IInitializeDbService {
    void InitializeDB(List<BaseHero> baseHeroCollection);
}

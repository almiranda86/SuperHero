package com.superhero.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.superhero.domain.behavior.repository.persister.IBaseHeroPersister;
import com.superhero.domain.behavior.service.IInitializeDbService;
import com.superhero.domain.model.BaseHero;

@Service
public class InitializeDbService implements IInitializeDbService{

    @Autowired
    private final IBaseHeroPersister baseHeroPersister;

    public InitializeDbService(IBaseHeroPersister baseHeroPersister) {
        this.baseHeroPersister = baseHeroPersister;
    }
    
    public void InitializeDB(List<BaseHero> baseHeroCollection) {
        this.baseHeroPersister.saveAll(baseHeroCollection);
    }   
}

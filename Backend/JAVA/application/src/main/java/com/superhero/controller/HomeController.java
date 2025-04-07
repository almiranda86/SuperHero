package com.superhero.controller;

import org.springframework.web.bind.annotation.RestController;

import com.superhero.domain.behavior.handler.IGetHeroByPublicIdHandler;
import com.superhero.domain.behavior.repository.lookup.IBaseHeroLookup;
import com.superhero.domain.model.BaseHero;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;


@RestController
public class HomeController {

    @Autowired
    private final IGetHeroByPublicIdHandler getHeroByPublicIdHandler;

    @Autowired
    private final IBaseHeroLookup baseHeroLookup;

    public HomeController(IGetHeroByPublicIdHandler getHeroByPublicIdHandler,
                          IBaseHeroLookup baseHeroLookup) {
        this.getHeroByPublicIdHandler = getHeroByPublicIdHandler;
        this.baseHeroLookup = baseHeroLookup;
    }

    @GetMapping("/")
    public String index(){
        return "index.html";
    }

    @GetMapping("/get-hero-by-publicid/{publicid}")
    public ResponseEntity<BaseHero> GetHeroByGuid(@PathVariable String publicid){
        BaseHero baseHero = getHeroByPublicIdHandler.GetByPublicId(publicid);       
        return ResponseEntity.ok().body(baseHero);
    }


    @GetMapping("/list-all")
    public ResponseEntity<List<BaseHero>> ListAll(){
        List<BaseHero> allBaseHeros = baseHeroLookup.findAll();
        return ResponseEntity.ok().body(allBaseHeros);
    }

}

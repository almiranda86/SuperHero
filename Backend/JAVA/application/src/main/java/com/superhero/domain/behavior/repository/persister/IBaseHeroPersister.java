package com.superhero.domain.behavior.repository.persister;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.superhero.domain.model.BaseHero;

@Repository
public interface IBaseHeroPersister extends JpaRepository<BaseHero, Long>{
    

}

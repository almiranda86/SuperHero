package com.superhero.domain.behavior.repository.lookup;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import com.superhero.domain.model.BaseHero;

@Repository
public interface IBaseHeroLookup extends JpaRepository<BaseHero, Long>{

    @Query(value = "SELECT * FROM Base_Hero WHERE public_Id = ?1", nativeQuery = true)
    BaseHero getBaseHeroByPublicId(@Param("publicId") String publicId);

}

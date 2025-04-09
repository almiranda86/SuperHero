package com.superhero.repository.lookup;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.superhero.domain.behavior.repository.lookup.IExternalApiLookup;
import com.superhero.domain.behavior.service.external_service.IRestService;
import com.superhero.domain.model.custom_model.CompleteHero;

@Component
public class ExternalApiLookup implements IExternalApiLookup {

    @Autowired
    private final IRestService restService;

    @Value( "${heroapi.token}" )
    private String apiToken;
    
    @Value( "${heroapi.url}" )
    private String apiUrl;

    public ExternalApiLookup(IRestService restService) {
        this.restService = restService;
    }

    @Override
    public CompleteHero GetCompleteHeroById(int heroId) {
        // TODO Auto-generated method stub
        String apiResponse = this.restService.DoRestCall(String.format("%s%s", apiUrl, apiToken), String.valueOf(heroId));
        
        ObjectMapper mapper = new ObjectMapper();
        try {
            CompleteHero hero = mapper.readValue(apiResponse, CompleteHero.class);

            if(hero != null)
                return hero;

        } catch (JsonMappingException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        } catch (JsonProcessingException e) {
            // TODO Auto-generated catch block
            e.printStackTrace();
        }
        

        return new CompleteHero();
    }

}

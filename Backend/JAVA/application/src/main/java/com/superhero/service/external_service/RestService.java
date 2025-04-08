package com.superhero.service.external_service;

import org.springframework.stereotype.Component;

import com.superhero.domain.behavior.service.external_service.IRestService;

@Component
public class RestService implements IRestService{

    @Override
    public String DoRestCall(String uri, String uriParams) {
        // TODO Auto-generated method stub
        throw new UnsupportedOperationException("Unimplemented method 'DoRestCall'");
    }

}

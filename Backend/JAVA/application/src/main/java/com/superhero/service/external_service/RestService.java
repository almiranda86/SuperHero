package com.superhero.service.external_service;

import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;
import org.springframework.web.client.RestTemplate;

import com.superhero.domain.behavior.service.external_service.IRestService;

@Component
public class RestService implements IRestService{

    @Override
    public String DoRestCall(String uri, String uriParams) {
        
        RestTemplate restTemplate = new RestTemplate();
        String url = String.format("%s/%s", uri, uriParams);
        
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);

        ResponseEntity<String> response = restTemplate.getForEntity(url, String.class);
        
        if(response.getStatusCode().equals(HttpStatus.OK))
            return response.getBody();

        return new String("");
    }
}

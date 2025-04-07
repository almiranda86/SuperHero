package com.superhero.service;

import java.time.LocalDateTime;

import org.springframework.http.HttpStatus;

public class ServiceResponse {

    public LocalDateTime IssuedOn;
    public HttpStatus Status;
    public String StatusDescription;

    public LocalDateTime getIssuedOn() {
        return IssuedOn;
    }

    public void setIssuedOn() {
        IssuedOn = LocalDateTime.now();
    }

    public HttpStatus getStatus() {
        return Status;
    }

    public void setStatus(HttpStatus status) {
        Status = status;
    }

    public String getStatusDescription() {
        return StatusDescription;
    }

    public void setStatusDescription(String statusDescription) {
        StatusDescription = statusDescription;
    }

    public void SetOk() {
        this.Status = HttpStatus.OK;
    }

    public void SetInternalServerError() {
        this.Status = HttpStatus.INTERNAL_SERVER_ERROR;
    }
}

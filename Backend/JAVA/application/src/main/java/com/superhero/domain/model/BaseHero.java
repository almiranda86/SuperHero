package com.superhero.domain.model;

import java.io.Serializable;
import java.util.UUID;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;

@Table(name = "Base_Hero")
@Entity
public class BaseHero implements Serializable{

    @Column(name="public_Id")
    public String publicId;
    
    @Id
    @Column(name="private_Id")
    public Integer privateId;
    
    @Column(name="name")
    public String name;
    
    public BaseHero(){
        
    };

    public BaseHero(String name, Integer privateId){
        this.name = name;
        this.privateId = privateId;
        this.publicId = generateGuid();
    }

    public BaseHero(String publicId, Integer privateId, String name) {
        this.publicId = publicId;
        this.privateId = privateId;
        this.name = name;
    }

    private String generateGuid(){
        UUID guid = UUID.randomUUID();
        return guid.toString();
    }

    public String getPublicId() {
        return publicId;
    }

    public void setPublicId(String publicId) {
        this.publicId = publicId;
    }

    public Integer getPrivateId() {
        return privateId;
    }

    public void setPrivateId(Integer privateId) {
        this.privateId = privateId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public int hashCode() {
        final int prime = 31;
        int result = 1;
        result = prime * result + ((privateId == null) ? 0 : privateId.hashCode());
        return result;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        BaseHero other = (BaseHero) obj;
        if (privateId == null) {
            if (other.privateId != null)
                return false;
        } else if (!privateId.equals(other.privateId))
            return false;
        return true;
    }
    
    
}

package com.superhero.application;

import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Configuration;

import com.superhero.domain.behavior.service.ISetupService;
import com.superhero.domain.model.BaseHero;
import com.superhero.service.InitializeDbService;


@Configuration
public class SetupEnvironment implements ISetupService, CommandLineRunner {

    private final String RESOURCE_FILE_PATH = "src\\main\\resources\\static\\heroes.txt";

    private final InitializeDbService initializeDbService;

    public SetupEnvironment(InitializeDbService initializeDbService) {
        this.initializeDbService = initializeDbService;
    }

    public void DoSetup() {
        List<BaseHero> baseHeroCollection = new ArrayList<BaseHero>();

        // read text file
        try {
            //create the collection to be inserted based on the file values
            List<String> allLines = Files.readAllLines(Paths.get(RESOURCE_FILE_PATH));

            int count = 1;
            for (String line : allLines) {
                var baseHero = new BaseHero(line, count);
                baseHeroCollection.add(baseHero);
                count++;
            }
        } catch (Exception e) {
            System.err.println("Resource file not found. Ex:" + e.getMessage());
        }

        // pass List to InitializeDB
        this.initializeDbService.InitializeDB(baseHeroCollection);
    }

    @Override
    public void run(String... args) throws Exception {
        DoSetup();
    }
}

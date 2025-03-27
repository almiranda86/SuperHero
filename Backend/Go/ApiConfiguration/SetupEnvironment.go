package api_configuration

import (
	"bufio"
	"fmt"
	"os"
	"strconv"

	domain_model "github.com/almiranda86/superhero-go/Domain/Model"
	baseHeroService "github.com/almiranda86/superhero-go/Services"
)

func DoSetup() {
	var heroes = generateHeroesFromResourceContent()

	if heroes == nil {
		//log error and break
		panic("")
	}

	baseHeroService.InitializeDB(&heroes)
}

func generateHeroesFromResourceContent() []domain_model.BaseHero {
	const INITIAL_DB_VALUES_PATH = "Domain\\Resources\\heroes.txt"
	var i int = 1
	var heroes = []domain_model.BaseHero{}

	file, _ := os.Open(INITIAL_DB_VALUES_PATH)
	defer file.Close()

	r := bufio.NewReader(file)

	for {
		line, _, err := r.ReadLine()
		if len(line) > 0 {
			var hero = fmt.Sprintf("%s", line)
			heroes = append(heroes, domain_model.CreateBaseHero(hero, strconv.Itoa(i)))
		}
		if err != nil {
			//log error
			break
		}
		i++
	}

	return heroes
}

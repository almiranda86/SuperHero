package services

import (
	"fmt"

	domain_behavior_service "github.com/almiranda86/superhero-go/Domain/Behavior/Service"
	domain_model "github.com/almiranda86/superhero-go/Domain/Model"
)

// Log logs the given message to a file.
func (fl *FileLogger) Log(message string) {
	// Code to write the message to a file.
	fmt.Println("[File Logger] " + message)
}

func InitializeDB(heroes *[]domain_model.BaseHero) domain_behavior_service.IBaseHeroService {

}

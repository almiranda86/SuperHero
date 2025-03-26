package domain_model_custom

import (
	domain_model "github.com/almiranda86/superhero-go/Domain/Model"
	domain_model_base "github.com/almiranda86/superhero-go/Domain/Model/BaseModel"
)

type CompleteHero struct {
	Powerstats     domain_model.Powerstats
	Biography      domain_model.Biography
	Appearance     domain_model.Appearance
	Work           domain_model.WorK
	Connections    domain_model.Connections
	Image          domain_model.Image
	BaseProperties domain_model_base.BaseModel
}

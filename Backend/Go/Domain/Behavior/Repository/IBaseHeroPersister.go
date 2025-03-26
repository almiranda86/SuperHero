package domain_behavior_repository

import domain_model "github.com/almiranda86/superhero-go/Domain/Model"

type IBaseHeroService interface {
	CreateBaseHero(baseHeroCollection []domain_model.BaseHero)
}

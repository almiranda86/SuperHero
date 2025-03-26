package domain_model

import (
	domain_model_base "github.com/almiranda86/superhero-go/Domain/Model/BaseModel"
	"github.com/google/uuid"
)

func CreateBaseHero(name string, privateId string) BaseHero {
	uuid := uuid.New()

	baseHero := BaseHero{
		BaseProperties: domain_model_base.BaseModel{
			Name: name,
			PrivateId: domain_model_base.PrivateId{
				PrivateId: privateId,
			},
			PublicId: domain_model_base.GuidId{
				PublicId: uuid.String(),
			},
		},
	}

	return baseHero
}

type BaseHero struct {
	BaseProperties domain_model_base.BaseModel

	CreateBaseHero func(name string, privateId string)
}

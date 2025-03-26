package domain_model_base

type BaseModel struct {
	Name      string
	PrivateId PrivateId
	PublicId  GuidId
}

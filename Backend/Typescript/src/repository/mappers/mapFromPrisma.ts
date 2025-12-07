import { CompleteHero } from "../../domain/entities/custom/complete-hero.js";

export function fromPrisma(data: any): CompleteHero {
  const hero = new CompleteHero();

  //
  // Hero root fields
  //
  hero.publicId = data.id;
  hero.PublicId = data.publicId;
  hero.name = data.name;

  //
  // Powerstats
  //
  if (data.powerstats) {
    hero.powerstats.Intelligence = data.powerstats.intelligence;
    hero.powerstats.Strength = data.powerstats.strength;
    hero.powerstats.Speed = data.powerstats.speed;
    hero.powerstats.Durability = data.powerstats.durability;
    hero.powerstats.Power = data.powerstats.power;
    hero.powerstats.Combat = data.powerstats.combat;
  }

  //
  // Biography
  //
  if (data.biography) {
    hero.biography.FullName = data.biography.fullName;
    hero.biography.AlterEgos = data.biography.alterEgos;
    hero.biography.Aliases = data.biography.aliases?.map((a: any) => a.value) ?? [];
    hero.biography.PlaceOfBirth = data.biography.placeOfBirth;
    hero.biography.FirstAppearance = data.biography.firstAppearance;
    hero.biography.Publisher = data.biography.publisher;
    hero.biography.Alignment = data.biography.alignment;
  }

  //
  // Appearance
  //
  if (data.appearance) {
    hero.appearance.Gender = data.appearance.gender;
    hero.appearance.Race = data.appearance.race;
    hero.appearance.Height = data.appearance.height?.map((h: any) => h.value) ?? [];
    hero.appearance.Weight = data.appearance.weight?.map((w: any) => w.value) ?? [];
    hero.appearance.EyeColor = data.appearance.eyeColor;
    hero.appearance.HairColor = data.appearance.hairColor;
  }

  //
  // Work
  //
  if (data.work) {
    hero.work.occupation = data.work.occupation;
    hero.work.baseOfOperation = data.work.baseOfOperation;
  }

  //
  // Connections
  //
  if (data.connections) {
    hero.connections.GroupAffiliation = data.connections.groupAffiliation;
    hero.connections.Relatives = data.connections.relatives;
  }

  //
  // Image
  //
  if (data.image) {
    hero.image.URL = data.image.url;
  }

  return hero;
}

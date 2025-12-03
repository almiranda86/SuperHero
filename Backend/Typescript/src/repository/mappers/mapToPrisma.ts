import type { CompleteHero } from "../../domain/entities/custom/complete-hero.js";

export function toPrisma(hero: CompleteHero) {
    return {
      id: hero.publicId ?? undefined,
      publicId: hero.PublicId,
      name: hero.name,
  
      powerstats: {
        create: {
          intelligence: hero.powerstats.Intelligence,
          strength: hero.powerstats.Strength,
          speed: hero.powerstats.Speed,
          durability: hero.powerstats.Durability,
          power: hero.powerstats.Power,
          combat: hero.powerstats.Combat,
        }
      },
  
      biography: {
        create: {
          fullName: hero.biography.FullName,
          alterEgos: hero.biography.AlterEgos,
          aliases: hero.biography.Aliases ?? [],
          placeOfBirth: hero.biography.PlaceOfBirth,
          firstAppearance: hero.biography.FirstAppearance,
          publisher: hero.biography.Publisher,
          alignment: hero.biography.Alignment,
        }
      },
  
      appearance: {
        create: {
          gender: hero.appearance.Gender,
          race: hero.appearance.Race,
          height: hero.appearance.Height ?? [],
          weight: hero.appearance.Weight ?? [],
          eyeColor: hero.appearance.EyeColor,
          hairColor: hero.appearance.HairColor,
        }
      },
  
      work: {
        create: {
          occupation: hero.work.occupation,
          baseOfOperation: hero.work.baseOfOperation
        }
      },
  
      connections: {
        create: {
          groupAffiliation: hero.connections.GroupAffiliation,
          relatives: hero.connections.Relatives
        }
      },
  
      image: {
        create: {
          url: hero.image.URL
        }
      }
    };
  }
  
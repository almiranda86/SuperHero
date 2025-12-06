import type { CompleteHero } from "../../domain/entities/custom/complete-hero.js";

export function toPrisma(hero: CompleteHero) {
  return {
    id: hero.publicId ?? undefined,
    publicId: hero.PublicId,
    name: hero.name,

    //
    // Powerstats
    //
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

    //
    // Biography + aliases (1-N)
    //
    biography: {
      create: {
        fullName: hero.biography.FullName,
        alterEgos: hero.biography.AlterEgos,
        placeOfBirth: hero.biography.PlaceOfBirth,
        firstAppearance: hero.biography.FirstAppearance,
        publisher: hero.biography.Publisher,
        alignment: hero.biography.Alignment,

        aliases: {
          create: (hero.biography.Aliases ?? []).map(alias => ({
            value: alias
          }))
        }
      }
    },

    //
    // Appearance + height/weight (1-N)
    //
    appearance: {
      create: {
        gender: hero.appearance.Gender,
        race: hero.appearance.Race,
        eyeColor: hero.appearance.EyeColor,
        hairColor: hero.appearance.HairColor,

        height: {
          create: (hero.appearance.Height ?? []).map(h => ({
            value: h
          }))
        },

        weight: {
          create: (hero.appearance.Weight ?? []).map(w => ({
            value: w
          }))
        }
      }
    },

    //
    // Work
    //
    work: {
      create: {
        occupation: hero.work.occupation,
        baseOfOperation: hero.work.baseOfOperation
      }
    },

    //
    // Connections
    //
    connections: {
      create: {
        groupAffiliation: hero.connections.GroupAffiliation,
        relatives: hero.connections.Relatives
      }
    },

    //
    // Image
    //
    image: {
      create: {
        url: hero.image.URL
      }
    }
  };
}

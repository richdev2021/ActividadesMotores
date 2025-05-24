export const typeDefs = `#graphql
  type Query{
    Hello: String!
    CharacterDataList: [CharacterData]!
    CharacterDataByStyleName(StyleName: String): [CharacterData]!
  }
  type CharacterData{
    id: ID!
    MoveSpeed: Float!
    JumpForce: Float!
    StyleName: String!
  }
`;
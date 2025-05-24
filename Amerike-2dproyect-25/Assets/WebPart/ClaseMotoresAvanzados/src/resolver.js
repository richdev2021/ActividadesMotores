export const resolvers = {
    Query:{
        Hello: (root, args) => "Hello World, Graphql",
        CharacterDataList: async (root,args) => CharacterData.find({}),
        CharacterDataByStyleName: async (root, args)=> {
            const {StyleName}= args;
            return CharacterData.find({StyleName});
    }
    }
}
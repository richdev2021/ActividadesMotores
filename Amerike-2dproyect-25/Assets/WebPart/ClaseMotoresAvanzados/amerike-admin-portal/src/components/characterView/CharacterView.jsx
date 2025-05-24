import { useQuery } from '@apollo/client';
import './CharacterView.css'

/*const characterDataList = gql`{
    characterDataList{
        id
        MoveSpeed
        JumpForce
        StyleName
    }
}`*/

const CharacterView = () => {
    /*const{data, loading, error} = useQuery(characterDataList);
    if(loading) return <div>loading characters...</div>
    if(error) return <div>error qwp {error.message}</div>

    console.log(data.CharacterDataList)*/

    /*{
        data.characterDataList.forEach(CharacterData => {
        const{jumpforce, movespeed, stylename, id} = CharacterData;
        });
    }*/
    return(
        <>
        <div>Character editor panel</div>
            <div>Character editor panel</div>
                <div className='field'>
                <div>style Name</div>
                <input placeholder="style name " type="text"></input>
            </div>
            <div className='field'>
            <   div>move speed</div>
            <   input placeholder="Move Speed " type="number"></input>
            </div>
            <div className='field'>
                <div>jump force</div>
                <input  placeholder="JumpForce " type="number"></input>
            </div>
            <div className='field'>
            <   button>submit</button>
            </div>
        </>
    );
}

export default CharacterView;
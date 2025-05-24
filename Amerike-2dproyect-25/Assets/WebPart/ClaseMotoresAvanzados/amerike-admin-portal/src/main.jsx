import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { ApolloClient, ApolloProvider } from '@apollo/client'

/*const client = new ApolloClient({
  uri: "http://localhost:4000/graphql"

});*/
/*Client={client}*/
createRoot(document.getElementById('root')).render(
  <StrictMode>
    <ApolloProvider>
    <App />
    </ApolloProvider>

  </StrictMode>,
);

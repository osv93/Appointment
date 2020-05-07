import React, { Component} from 'react';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemText from '@material-ui/core/ListItemText';

class Card extends Component {
    render(){
        return (
            <div style={{'margin':10}}>
            <List>
              {this.props.patients.map((patient, index) => {            
              return  <ListItem button divider key={index} >            
                        <ListItemText primary={patient.name} />
                        <img alt="imagen" src={patient.avatar_url} style={{'width':100}}/>
                      </ListItem>   
              })}
            </List>
          </div>
        );
    }
}

export default Card;
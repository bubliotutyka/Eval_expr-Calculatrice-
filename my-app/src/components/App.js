import React from 'react';
import * as S from './style';
import Axios from 'axios';

const padTouch = [
  {
    value: '1',
  },
  {
    value: '2',
  },
  {
    value: '3',
  },
  {
    value: '+',
  },
  {
    value: '4',
  },
  {
    value: '5',
  },
  {
    value: '6',
  },
  {
    value: '-',
  },
  {
    value: '7',
  },
  {
    value: '8',
  },
  {
    value: '9',
  },
  {
    value: '*',
  },
  {
    value: '=',
  },
  {
    value: '0',
  },
  {
    value: '%',
  },
  {
    value: '/',
  },
  {
    value: 'C',
  },
  {
    value: '(',
  },
  {
    value: ')',
  }
]

const isOperator = (operator) => {
  const OPERATOR = ["+", "-", "*", "/", "%"];

  if (OPERATOR.includes(operator))
    return true;
  return false;
}

class App extends React.Component {
  state = {
    displayValue: "0",
    openParentheses: 0,
    closeParentheses: 0,
  }

  padTouch = (item, key) => {
    return (
      <S.padTouch key={key} onClick={() => this.handleClick(item.value)}>
        {item.value}
      </S.padTouch>
    )
  }

  handleClick = (value) => {
    const {displayValue, openParentheses, closeParentheses} = this.state;

    if (value === "=") {
      this.handleEgual();
    }
    else if (value === "C") {
      this.setState({
        displayValue: '0',
        openParentheses: 0,
        closeParentheses: 0,
      });
    }
    else if (isOperator(value)) {
      const lastIndex = displayValue.length -1;
      if (isOperator(displayValue[lastIndex])) {
        let newDisplayValue = "";

        for (let i = 0; i < displayValue.length - 1; i++) {
          newDisplayValue += displayValue[i];
        }
        this.setState({displayValue: newDisplayValue + value});
      } else if (displayValue[0] !== '0') {
        this.setState({displayValue: displayValue + value});
      }
    }
    else if (value === "(" || value === ")") {
      if (value === ")") {
        // if (openParentheses > closeParentheses && !isNaN(displayValue[displayValue.length - 1]))
          this.setState({
            displayValue: displayValue + value,
            closeParentheses: closeParentheses + 1
          }); 
      } else {
        if (displayValue[0] === '0') {
          this.setState({ 
            displayValue: value, 
            openParentheses: openParentheses + 1
          });
        } else {
          this.setState({ 
            displayValue: displayValue + value, 
            openParentheses: openParentheses + 1
          });
        }
      }
    }
    else {
      if (displayValue[0] === '0') {
        this.setState({displayValue: value});
      } else {
        this.setState({displayValue: displayValue + value});
      }
    }
  }

  handleEgual = () => {
    const {displayValue} = this.state;
    const headers = {
      "Content-Type": "application/json",
      "cache-control": "no-cache",
    };
    const data = {
      expr: displayValue,
    };

    Axios.post("http://localhost:5000/api/bsq", data, {headers})
    .then((res) => this.setState({displayValue: res.data.result}))
    .catch((err) => console.log(err));
  }

  render() {
    const {displayValue} = this.state;

    return (
      <S.calcContainer>

        <S.calcDisplay>
          <S.displayValue>{displayValue}</S.displayValue>
        </S.calcDisplay>

        <S.calcPad>
          {
            padTouch.map((item, key) => this.padTouch(item, key))
          }
        </S.calcPad>

      </S.calcContainer>
    );
  }
}

export default App;

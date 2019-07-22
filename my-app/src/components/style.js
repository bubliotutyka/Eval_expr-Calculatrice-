import styled from '@emotion/styled';
import Color from './Color';

export const calcContainer = styled.div`
  background-color: ${Color.lightGrey};
  padding: 2em 1em;
  width: 400px;
  margin: 3em 4em;
  box-shadow: ${Color.hoverShadow};
`;

export const calcDisplay = styled.div`
  width: 92%;
  height: 50px;
  background-color: ${Color.darkGrey};
  padding: .5em 1em;
  display: flex;
`;

export const displayValue = styled.p`
  margin: 0;
  color: ${Color.white};
  width: 100%;
  height: 100%;
  text-align: right;
  font-size: 2em;
`;

export const calcPad = styled.div`
  margin-top: 1em;
`;

export const padTouch = styled.button`
  width: 80px;
  height: 80px;
  background-color: ${Color.white};
  outline: none;
  box-shadow: ${Color.shadow};
  font-size: 1.5em;
  margin: 10px;
  border-radius: 50%;

  &:hover {
    cursor: pointer;
    box-shadow: ${Color.hoverShadow};
  }
`;
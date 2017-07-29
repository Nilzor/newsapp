import React, { Component } from 'react';

import ArticleText from '../components/article/article-text';
import ArticleImage from '../components/article/article-image';

export default class ComponentResolver {
    renderComponent(componentData, key) {
        switch (componentData.type) {
            case 'text' : return (
                <ArticleText data={componentData} key={key} />  
            )
            case 'image' : return (<ArticleImage data={componentData} key={key} />)
        }
        return null;
    }
}
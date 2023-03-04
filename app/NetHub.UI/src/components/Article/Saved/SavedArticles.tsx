import React from 'react';
import { useQueryClient } from 'react-query';
import { CSSTransition, TransitionGroup } from 'react-transition-group';
import { useSavedArticlesContext } from '../../../pages/Saved/SavedSpace.Provider';
import ErrorBlock from '../../Layout/ErrorBlock';
import ArticleShort from '../Shared/ArticleShort';
import cl from './SavedArticles.module.sass';
import SavedArticlesSkeleton from './SavedArticlesSkeleton';
import './transitions.css';
import { _myArticlesApi } from "../../../api";
import { ISimpleLocalization } from "../../../types/api/ISimpleLocalization";
import { QueryClientKeysHelper } from "../../../utils/QueryClientKeysHelper";

const SavedArticles = () => {
  const { savedArticles, setSavedArticles } = useSavedArticlesContext();
  const queryClient = useQueryClient();

  async function handleSetArticle(localization: ISimpleLocalization) {
    setSavedArticles(
      savedArticles.data!.map((a) =>
        a.id === localization.id ? localization : a
      )
    );
  }

  async function removeFromSavedHandle(id: number, code: string) {
    await _myArticlesApi.toggleSave(id, code);
    const savedArticleIndex = savedArticles.data!.findIndex(
      (a) => a.articleId === id && a.languageCode === code
    );
    setSavedArticles(
      savedArticles.data!.filter((a, index) => index !== savedArticleIndex)
    );
  }

  const afterCounterRequest = (article: ISimpleLocalization) =>
    async function () {
      await queryClient.invalidateQueries(QueryClientKeysHelper.Keys.articles);
      await queryClient.invalidateQueries(QueryClientKeysHelper.Article(article.articleId));
      await queryClient.invalidateQueries(QueryClientKeysHelper.ArticleLocalization(article.articleId, article.languageCode));
    };

  return !savedArticles.isSuccess ? (
    <SavedArticlesSkeleton />
  ) : savedArticles.data.length === 0 ? (
    <ErrorBlock>Упс, Ви ще не зберегли статтей</ErrorBlock>
  ) : (
    <TransitionGroup className={cl.savedWrapper}>
      {savedArticles.data!.map((article) => (
        <CSSTransition
          key={article.id}
          timeout={500}
          classNames='item'
        >
          <ArticleShort
            localization={article}
            setLocalization={handleSetArticle}
            afterCounterRequest={afterCounterRequest(article)}
            save={{
              actual: true,
              handle: async () =>
                await removeFromSavedHandle(
                  article.articleId,
                  article.languageCode
                ),
            }}
            time={{ before: 'збережено', show: 'saved' }}
          />
        </CSSTransition>
      ))}
    </TransitionGroup>
  );
};

export default SavedArticles;
